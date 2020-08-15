import { Component, OnInit } from '@angular/core';
import { ContactService } from 'src/app/services/contact.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-contact-detail',
  templateUrl: './contact-detail.component.html',
  styleUrls: ['./contact-detail.component.css']
})
export class ContactDetailComponent implements OnInit {

  currentContact = null;
  message = '';
  constructor(
    private _contactService: ContactService,
    private _route: ActivatedRoute,
    private _router: Router) { }

  
  ngOnInit(): void {
    this.message = '';
    this.getContact(this._route.snapshot.paramMap.get('id'));
  }

  getContact(id): void {
    this._contactService.get(id)
      .subscribe(
        data => {
          this.currentContact = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  updateStatus(status): void {
    const data = {
      id: this.currentContact.id,    
      status: status
    };    
    this._contactService.update(this.currentContact.id, data)
      .subscribe(
        response => {
          this.currentContact.status = status;
          console.log(response);
          this._router.navigate(['/contacts']);
        },
        error => {
          console.log(error);
        });
  }

  updateContact(): void {
    this._contactService.update(this.currentContact.id, this.currentContact)
      .subscribe(
        response => {
          console.log(response);
          this.message = 'The contact was updated successfully!';
        },
        error => {
          console.log(error);
        });
  }

  deleteContact(): void {
    this._contactService.delete(this.currentContact.id)
      .subscribe(
        response => {
          console.log(response);
          this._router.navigate(['/contacts']);
        },
        error => {
          this._router.navigate(['/contacts']);
          console.log(error);
        });
  }
}
