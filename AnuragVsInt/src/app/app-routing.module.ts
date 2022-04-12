import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GiftsComponent } from './gifts/gifts.component';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { UserProfileComponent } from './user-profile/user-profile.component';

const routes: Routes = [
  {path: "login", component: LoginComponent},
  {path: "signup", component: SignUpComponent},
  {path: "user/:id", component: UserProfileComponent},
  {path: "gifts", component: GiftsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
