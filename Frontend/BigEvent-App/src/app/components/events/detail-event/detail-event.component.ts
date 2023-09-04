import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Constants } from '@app/utils/constants';

@Component({
  selector: 'app-detail-event',
  templateUrl: './detail-event.component.html',
  styleUrls: ['./detail-event.component.scss']
})
export class DetailEventComponent implements OnInit {

  form!: FormGroup;
  public messageFieldRequired: string = "Field Required";
  public patternPhone = Constants.PATTERN_PHONE;

  get f() : any{
    return this.form.controls;
  }

  public validation() : void{

    this.form = this.formBuilder.group({

      email: ["", [ Validators.required, Validators.email ]],
      eventDate: ["", [ Validators.required ]],
      imageUrl: ["", [ Validators.required ]],
      local: ["", [  Validators.required ]],
      maximumGuest: ["", [ Validators.required, Validators.max(120000) ]],
      phone: ["", [ Validators.required, Validators.pattern(Constants.PATTERN_PHONE) ]],
      theme: ["", [ Validators.required, Validators.minLength(4), Validators.maxLength(50) ]]

    });

  }

  public formValidator(fieldForm: FormControl) : any{
    return {'is-invalid' : fieldForm.errors && fieldForm.touched};
  }

  public resetForm() : void{
    this.form.reset();
  }

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

}
