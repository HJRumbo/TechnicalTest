import { Component, OnInit } from '@angular/core';
import { LoginResponse } from '../../../auth/models/login-reponse';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth/services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  currentUser?: LoginResponse;

  constructor(private router: Router,
    private authService: AuthService) { 
      this.authService.currentUser.subscribe(u => this.currentUser = u);


  }

  ngOnInit(): void {
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
    }

}
