import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Gift } from '../GiftModel';
import { Order } from '../OrderModel';
import { UserService } from '../user.service';

@Component({
  selector: 'app-gifts',
  templateUrl: './gifts.component.html',
  styleUrls: ['./gifts.component.css']
})
export class GiftsComponent implements OnInit {

  gifts: any;
  imgurl: string = "";
  orders: any;
  cartItems:any[] = [];

  Orders: Order={
    orderId: 0,
    loginId: 0
  };

  // CartItems: Gift = {
  //   giftId: 0,
  //   giftName: '',
  //   price: 0,
  //   quantity: 0,
  //   giftImg: ''
  // }


  constructor(private _userService: UserService,
    private route: ActivatedRoute,
    private router: Router) { }


    allGifts(): void{
      this._userService.getAllGifts()
      .subscribe(
        (gifts:any) => {
          this.imgurl = "https://res.cloudinary.com/anurag-cloud/image/upload/v1649579980/ang_proj_Img/";
           this.gifts = gifts
          console.log(gifts);
        },
        (error: any) => {
          console.log(error);
        }
      )
    }

    placeOrder(): void{
      if(localStorage.getItem("loggedUserId")){
        if(localStorage.getItem("gifts")){
        // console.log(localStorage.getItem("loggedUserId"))
        const data = {
          loginId: parseInt(localStorage.getItem("loggedUserId") || "")
        }
        this._userService.postOrder(data).subscribe(res=>{
          console.log(res);
          localStorage.setItem("currentOrderId", res)
          this.addOrderDetails();
        })

      }else{
        alert("No Items in cart");
      }
    }else{
      alert("YOu are not logged in");
    }
    }

    addOrderDetails(): void{
          var item = JSON.parse(localStorage.getItem("gifts") || "");
          for(let i in this.cartItems){

          const data =[ {

            orderId: parseInt(localStorage.getItem("currentOrderId") || ""),
            giftId: item[i].giftId

          }
        ]
          this._userService.postOrderDetails(data).subscribe(res=>{console.log(res)})
          localStorage.removeItem("gifts");
        }
    }


    // latestUserID(): void{
    //   this._userService.getLatestUserId().subscribe(res=>{
    //     localStorage.setItem("currentOrderId", res.orderId);
    //     console.log(res);
    //   })

    // }

    addCart(gift: Gift){
      if(localStorage.getItem("loggedUserId")){
      const exist = this.cartItems.find((item) => {
        return item.giftId === gift.giftId;
      });
      if(exist) {

        exist.quantity++;
        localStorage.setItem("gifts", JSON.stringify(this.cartItems));
      }
      else{
        this.cartItems.push({
          orderId: parseInt(localStorage.getItem("currentOrderId") || ""),
          giftId: gift.giftId,
          quantity: gift.quantity
        });
        localStorage.setItem("gifts", JSON.stringify(this.cartItems));
        var item = JSON.parse(localStorage.getItem("gifts") || "");

      }

      console.log(this.cartItems);
      }else{
        alert("You are not logged in")
      }

    }


  ngOnInit(): void {
    this.allGifts();
// this.latestUserID();
  }

}
