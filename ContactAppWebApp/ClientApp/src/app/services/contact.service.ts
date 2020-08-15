import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
const baseUrl = 'https://localhost:44305/api/contact';
@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private _http: HttpClient) { }

  getAll(): Observable<any> {
    return this._http.get(baseUrl+"/GetAll");
  }

  get(id): Observable<any> {
    return this._http.get(`${baseUrl}/${id}`);
  }

  create(data): Observable<any> {
    return this._http.post(baseUrl+"/SaveContact", data);
  }

  update(id, data): Observable<any> {
    return this._http.put(`${baseUrl}/${id}`, data);
  }

  
  delete(id): Observable<any> {
    return this._http.delete(`${baseUrl}/${id}`);
  }

  deleteAll(): Observable<any> {
    return this._http.delete(baseUrl+"/DeleteAll");
  }

  findByName(name): Observable<any> {
   
    return this._http.get(`${baseUrl+"/SearchContact"}?name=${name}`);
  }
}
