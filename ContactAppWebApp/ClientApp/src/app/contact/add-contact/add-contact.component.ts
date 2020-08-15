import { Component, OnInit } from '@angular/core';
import { ContactService } from '../../services/contact.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent implements OnInit {

  form: FormGroup;
  submitted = false;
  constructor(private _contactService: ContactService,   private _route: ActivatedRoute,
    private _router: Router,private fb: FormBuilder) {
      this.form = fb.group({
        firstName:  ['', [Validators.required]],
        lastName:  ['', [Validators.required]],
        email:  ['', [Validators.required, Validators.email]],
        phoneNumber:  ['', [Validators.required, Validators.pattern('[+0-9]+'), Validators.maxLength(10)]],    
        status: true    
      }); 
    }

  ngOnInit(): void {
  }
  submit() {
    this._contactService.create(this.form.value)
      .subscribe(
        response => {
          console.log(response);
          this.submitted = true;
          this._router.navigate(['/contacts']);
        },
        error => {
          console.log(error);
        });
  }

  get firstName() {
    return this.form.get('firstName');
  }

  get lastName() {
    return this.form.get('lastName');
  }

  get email() {
    return this.form.get('email');
  }

  get phoneNumber() {
    return this.form.get('phoneNumber');
  }
  
}
