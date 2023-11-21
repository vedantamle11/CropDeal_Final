import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ViewcropsService } from '../_Services/viewcrops.service';

@Component({
  selector: 'app-view-your-crops',
  templateUrl: './view-your-crops.component.html',
  styleUrls: ['./view-your-crops.component.css'],
})
export class ViewYourCropsComponent implements OnInit {
  cropdata: any[] = [];
  cropDataSaved: any;
  userId: any;
  searchQuery: string = '';
  filteredCrops: any[] = [];
  isResultVisible: boolean = true;

  constructor(private service: ViewcropsService, private route: Router) {
    this.viewyourcrop();
  }

  ngOnInit(): void {}

  viewyourcrop() {
    this.userId = localStorage.getItem('userid');

    this.service.ViewYourCrop(this.userId).subscribe(
      (data: any) => {
        this.cropdata = data;
        console.log(this.cropdata);
        this.cropDataSaved = data;
      },
      (err) => {
        if (err.status == 403) {
          this.route.navigate(['/Unauthorized']);
        } else {
          alert('Some error occurred! Please try again later.');
        }
      }
    );
  }

  search(): void {
    if (this.searchQuery && this.searchQuery.trim() !== '') {
      this.filteredCrops = this.cropdata.filter((crop: any) =>
        crop.cropName.toLowerCase().includes(this.searchQuery.toLowerCase())
      );
      this.isResultVisible = true;
    } else {
      this.filteredCrops = [];
      this.isResultVisible = false;
    }
  }

  selectProduct(cropAdId: number): void {
    // this.route.navigate(['/product-detail', cropAdId]);
    let i = 0;
    for (i = 0; i < this.cropDataSaved.length; i++) {
      if (this.cropDataSaved[i].cropAdId == cropAdId) {
        this.cropdata = [];
        this.cropdata.push(this.cropDataSaved[i]);
        break;
      }
    }
  }
}
