

import { Component } from '@angular/core';
import { ProductService } from '../_Services/search-service.service';
import { ViewcropsService } from '../_Services/viewcrops.service';
import { Router } from '@angular/router';
import { GetCropDto } from '../_Models/crops.models';
import { CropOnSale } from '../_Models/crop-on-sale';
 @Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {


  Isloggedin: any;
  user: any;
  nn=10
  crops: GetCropDto[] = [];
  filteredCrops: any = [];
  searchQuery: string = '';
  searchResults=this.filteredCrops;
  cropdata:any;

  selectedProduct: any;

  isResultVisible: boolean = true;

  item:any;

  constructor(private router: Router,private productService: ProductService,private service:ViewcropsService,private route:Router) {   ;
  }
  ngOnInit(): void {
   }


   search(): void {
    if (this.searchQuery && this.searchQuery.trim() !== '') {
      this.productService.getCrops(this.searchQuery)
        .subscribe((crops: GetCropDto[]) => {
          this.filteredCrops.name = crops;
          console.log('Filtered Crops:', this.filteredCrops);
        });
    } else {
      this.filteredCrops = [];
      console.log('Filtered Crops:', this.filteredCrops);
    }
  }




  counter(length: number) {
    return Array.from({length}, (_, i) => i + 1);
  }



  viewcrop(crid:any){
    this.service.ViewCropById(crid).subscribe((data: any)=>{
      this.cropdata=data;
      console.log(this.cropdata)

     },(err: { status: number; })=>{

      if(err.status==403){
        this.route.navigate(['/Unauthorized'])

      }else{

        alert("Some error occured! come back later");
      }
    } );
    }


    selectProduct(cropAdId: number): void {
      // this.router.navigate(['/product-detail', cropAdId]);

    }





}















