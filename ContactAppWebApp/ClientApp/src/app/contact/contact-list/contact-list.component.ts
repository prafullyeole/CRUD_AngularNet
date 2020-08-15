import { Component, OnInit } from '@angular/core';
import { ContactService } from 'src/app/services/contact.service';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {
  contacts: any;
  currentContact = null;
  currentIndex = -1;
  title = '';
  constructor(private _contactService: ContactService) { }

  ngOnInit(): void {
    this.retrieveContacts();
  }
  retrieveContacts(): void {
    this._contactService.getAll()
      .subscribe(
        data => {
          this.contacts = data;
          this.currentContact = data[0];
          this.currentIndex=0;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  refreshList(): void {
    this.retrieveContacts();
    this.currentContact = null;
    this.currentIndex = -1;
  }

  setActiveContact(contact, index): void {
    this.currentContact = contact;
    this.currentIndex = index;
  }

  removeAllContacts(): void {
    this._contactService.deleteAll()
      .subscribe(
        response => {
          console.log(response);
          this.retrieveContacts();
        },
        error => {
          console.log(error);
        });
  }

  searchContact(): void { 
    this._contactService.findByName(this.title)
      .subscribe(
        data => {
          this.contacts = data;
          this.setActiveContact(data[0],0);
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }
}
