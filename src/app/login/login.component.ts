import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
user: any;
  userId:any = 0;
  userEmail:string = "";
  isAuth:boolean = false;
  sub: Subscription | undefined ;
  id: any;

  constructor(private _userService: UserService,
    private route: ActivatedRoute,
    private router: Router) { }

  loginForm = new FormGroup({
    email: new FormControl("", [Validators.required, Validators.pattern("^[a-z0-9]+(\.[_a-z0-9]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,15})$")]),
    pass: new FormControl("", [Validators.required, Validators.minLength(3), Validators.maxLength(15)]),
    // auth: new FormControl()
  })

  authUser(): void{
    const data = {
      email: this.loginForm.controls["email"].value,
      password: this.loginForm.controls["pass"].value,
      // isAuth: true
    }
    this._userService.getLoggedUser(data).subscribe(res => {
      localStorage.setItem("loggedUserId", res.loginId);

       this.userId =  localStorage.getItem("loggedUserId");
       this.userEmail = res.email;
       this.isAuth = res.isAuth;
      console.log(res)
      alert(res.email + "You are now logged in");
    },
    err => {
      console.log(err);
    })
  }



  ngOnInit(): void {

  }

}
