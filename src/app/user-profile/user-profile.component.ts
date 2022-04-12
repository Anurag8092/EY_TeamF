import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserService } from '../user.service';


@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  userEmail:string = "";
  currentUser: any;
  orders: any;
  isAuth: boolean = false;
  sub: Subscription | undefined ;
  id: any;

  imgurl: string = "";
  safeUrl: any;
  constructor(private _userService: UserService,
    private route: ActivatedRoute,
    private router: Router) {}

  getUser(id: number | null): void{
    this._userService.getUserById(id)
    .subscribe(
      (user: any) => {
        this.currentUser = user;
        this.isAuth = this.currentUser.isAuth;
       console.log(this.currentUser);
      },
      (error: any) => {
        console.log(error);
      }
    )
  }


  orderHistory(id: number): void{
    this._userService.getOrderHistory(id)
    .subscribe(
      (order:any) => {
        this.imgurl = "https://res.cloudinary.com/anurag-cloud/image/upload/v1649579980/ang_proj_Img/";
        this.orders = order;

        console.log(order);
      },
      (error: any) => {
        console.log(error);
      }
    )
  }

  logOut(id:number): void{
    localStorage.removeItem("loggedUserId")
    this._userService.logOutUser(id)
    .subscribe(
      (error: any) => {
        console.log(error);
      }
    )
  }

  ngOnInit(): void {
    this.sub = this.route.paramMap.subscribe(params => {
      this.id = params.get("id");
      this.getUser(this.id);
    })
  }
}
