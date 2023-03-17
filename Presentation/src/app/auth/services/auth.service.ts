import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, Observable, of, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginResponse } from '../models/login-reponse';
import { ResponseModel } from '../../shared/models/response-model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private currentUserSubject: BehaviorSubject<LoginResponse>;
  public currentUser: Observable<LoginResponse>;

  private baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient) { 
    this.currentUserSubject = new BehaviorSubject<LoginResponse>(JSON.parse(localStorage.getItem('currentUser') || 'null'));
    this.currentUser = this.currentUserSubject.asObservable();    
  }

  public get currentUserValue(): LoginResponse {
    return this.currentUserSubject.value;
  }

  login(userName: string, password: string) {
    const body = {userName, password};

    return this.http.post<ResponseModel<LoginResponse>>( `${this.baseUrl}/Auth/Login`, body )
      .pipe(
        tap( resp => localStorage.setItem('currentUser', JSON.stringify(resp.result)) ),
        tap( resp => this.currentUserSubject.next(resp.result) ),
        catchError(error => of(error))
      );
  }

  logout(){
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null!);
  }
}
