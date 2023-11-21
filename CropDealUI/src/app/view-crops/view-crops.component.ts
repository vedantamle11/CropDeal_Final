
import { Component, OnInit } from '@angular/core';
import { Payment } from '../_Models/payment';
import { PaymentService } from '../_Services/payment.service';
import { ViewcropsService } from '../_Services/viewcrops.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-crops',
  templateUrl: './view-crops.component.html',
  styleUrls: ['./view-crops.component.css'],
})
export class ViewCropsComponent implements OnInit {
  constructor(
    private service: ViewcropsService,
    private ser: PaymentService,
    private route: Router
  ) {
    this.viewcrop();
  }

  cropdata: any;
  cropDataSaved: any;
  userid: any;
  filteredCrops: any[] = [];
  searchQuery: string = '';
  isResultVisible: boolean = true;
  // item: any = null;

  ngOnInit(): void {}

  viewcrop() {
    this.service.ViewCrop().subscribe(
      (data) => {
        this.cropdata = data;
        this.cropDataSaved = data;
      },
      (err) => {
        if (err.status == 403) {
          this.route.navigate(['/Unauthorized']);
        } else {
          alert('Some error occurred! Please come back later.');
        }
      }
    );
  }

  payment(cropAdId: any, farmerId: any) {
    this.userid = localStorage.getItem('userid');
    var payment = new Payment();
    payment.cropAdid = cropAdId;
    payment.farmerId = farmerId;
    payment.userId = this.userid;
    this.ser.payment(payment).subscribe((result) => {
      if (result != null) {
        this.route.navigate(['/PaymentSuccess']);
      }
    });
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
