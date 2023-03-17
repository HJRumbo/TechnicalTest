import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  myForm: FormGroup = this.fb.group({
    userName: ['', [Validators.required, Validators.maxLength(20)]],
    password: ['', [Validators.required, Validators.maxLength(10)]]
  });

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    if(this.myForm.invalid){
      this.myForm.markAllAsTouched();
      return;
    }

    const { userName, password} = this.myForm.value;

    this.authService.login(userName, password)
      .subscribe(resp => {
        if ( resp.ok !== false ) {
          this.router.navigate(['/get-people'])
        }else {
          Swal.fire('No se pudo iniciar sesión', resp.error.message, 'error');
        }
      })
  }
}
