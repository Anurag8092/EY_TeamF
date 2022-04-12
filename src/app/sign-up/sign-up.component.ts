import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
signUpForm: FormGroup

  constructor(private fb: FormBuilder) {
    this.signUpForm = this.fb.group({
      name: new FormControl("", [Validators.required, Validators.minLength(3), Validators.maxLength(20), Validators.pattern("^[a-zA-Z]*$")]),
      email: new FormControl("", [Validators.required, Validators.pattern("^[a-z0-9]+(\.[_a-z0-9]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,15})$")]),
      pass: new FormControl("", [Validators.required, Validators.minLength(6), Validators.maxLength(15)]),
      cpass: new FormControl("", [Validators.required]),
      checkBox: new FormControl("", [Validators.required])
    },
    {
      validator: this.ConfirmPasswordValidator("pass", "cpass")
    })
   }



  onSubmit(){
console.log("Hello")
  }
  ngOnInit(): void {
  }

  ConfirmPasswordValidator(pass: string, cpass: string) {
    return (formGroup: FormGroup) => {
      let control = formGroup.controls[pass];
      let matchingControl = formGroup.controls[cpass];
      if(matchingControl.errors && !matchingControl.errors['ConfirmPasswordValidator'])
      return;
      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ ConfirmPasswordValidator: true });
      } else {
        matchingControl.setErrors(null);
      }
    };
  }




}


