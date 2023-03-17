import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { SavePersonComponent } from './person/pages/save-person/save-person.component';
import { GetPeopleComponent } from './person/pages/get-people/get-people.component';
import { SesionGuard } from './auth/guards/sesion.guard';

const routes: Routes = [
  { 
    path: 'login', 
    component: LoginComponent
  },
  { path: 'register', component: SavePersonComponent },
  { 
    path: 'get-people', 
    component: GetPeopleComponent, 
    canActivate: [ SesionGuard ], 
    canLoad: [ SesionGuard ] 
  },
  {
    path: '**',
    redirectTo: '/login'
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
