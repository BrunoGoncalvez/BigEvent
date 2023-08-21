import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';

import { ValidatorFields } from '@app/helpers/Class/ValidatorFields';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  public form!: FormGroup;
  public messageFieldRequired = "Field Required";

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  get f() : any{
    return this.form.controls;
  }

  public validation() : void{

    const formOptions: AbstractControlOptions = {
      validators: ValidatorFields.MustMatch('password', 'confirmPassword')
    }

    this.form = this.formBuilder.group({

      firstName: ['', [ Validators.required ]],
      lastName: ['', [ Validators.required ]],
      email:['', [ Validators.required, Validators.email ]],
      userName:['', [ Validators.required ]],
      password:['', [ Validators.required, Validators.minLength(6) ]],
      confirmPassword:['', [ Validators.required, Validators.minLength(6) ]],

    }, formOptions);

  }


}
