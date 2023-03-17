import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { LoginResponse } from '../models/login-reponse';

@Injectable({
  providedIn: 'root'
})
export class SesionGuard implements CanActivate {

  constructor(private router: Router,
    private authService: AuthService) {

  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | boolean {
    
      const currentUser = this.authService.currentUserValue;      

      if (currentUser) {
        // authorized so return true
        return true;
      } else if (state.url === '/login' && currentUser) {
        console.log("entra", state.url);
        
        this.router.navigate(['/get-people'], { queryParams: { returnUrl: state.url }});
        return false;
      } else {
        // not logged in so redirect to login page with the return url
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
        return false;
      }
  }
  
}
