import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';


import { Constants } from '@app/utils/constants';
import { ValidatorFields } from '@app/helpers/Class/ValidatorFields';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  public form! : FormGroup;
  public messageFieldRequired = "Field Required";


  constructor(private formBuilder: FormBuilder) { }


  get f() : any{
    return this.form.controls;
  }

  ngOnInit() {
    this.validation();
  }

  public validation(): void{

    const formOptions: AbstractControlOptions = {
      validators: ValidatorFields.MustMatch('password', 'confirmPassword')
    }

    this.form = this.formBuilder.group({

      education: ['', [ Validators.required ]],
      firstName: ['', [ Validators.required ]],
      lastName: ['', [ Validators.required ]],
      email:['', [ Validators.required, Validators.email ]],
      phone: ["", [ Validators.required, Validators.pattern(Constants.PATTERN_PHONE) ]],
      occupation:['', [ Validators.required ]],
      description:['', [ Validators.required, Validators.minLength(20)  ]],
      password:['', [ Validators.required, Validators.minLength(6) ]],
      confirmPassword:['', [ Validators.required, Validators.minLength(6) ]]

    }, formOptions);

  }


}
