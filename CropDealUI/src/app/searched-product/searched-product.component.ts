import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GetCropDto } from '../_Models/crops.models';
import { ProductService } from '../_Services/search-service.service';
import { PaymentService } from '../_Services/payment.service';
import { Payment } from '../_Models/payment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-detail',
  templateUrl: './searched-product.component.html',
  styleUrls: ['./searched-product.component.css']
})
export class searchedroducts implements OnInit {
  selectedProduct: any | undefined;
  userid: any;
  constructor(private routes: Router, private route: ActivatedRoute, private productService: ProductService, private ser: PaymentService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const cropId = params.get('id');
      if (cropId) {
        this.productService.getProductById(cropId).subscribe(product => {
          this.selectedProduct = product;
        });
      }
    });
    this.userid = localStorage.getItem('userid')
    console.log(this.userid)
  }


  payment(cropAdId: any, farmerId: any) {
    this.userid = localStorage.getItem('userid')
    var payment = new Payment();
    payment.cropAdid = cropAdId;
    payment.farmerId = farmerId;
    payment.userId = this.userid;
    this.ser.payment(payment).subscribe(result => {
      if (result != null) {

        this.routes.navigate(['/PaymentSuccess'])

      }
    })
  }



}















// import { Component, OnInit } from '@angular/core';

// @Component({
//   selector: 'app-searched-product',
//   templateUrl: './searched-product.component.html',
//   styleUrls: ['./searched-product.component.css']
// })
// export class SearchedProductComponent implements OnInit {

//   constructor() { }

//   ngOnInit(): void {
//   }

// }
