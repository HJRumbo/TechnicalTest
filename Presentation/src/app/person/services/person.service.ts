import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { ResponseModel } from '../../shared/models/response-model';
import { Person } from '../models/person';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getAllPeople(): Observable<Person[]>{ 
    return this.http.get<Person[]>(`${this.baseUrl}/Person/GetAllPeople`);  
  }

  post(person: Person): Observable<ResponseModel<Person>>{
    return this.http.post<ResponseModel<Person>>(`${this.baseUrl}/Person/SavePerson`, person);
  }
}
