import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SavePersonComponent } from './pages/save-person/save-person.component';
import { GetPeopleComponent } from './pages/get-people/get-people.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    SavePersonComponent,
    GetPeopleComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [
    SavePersonComponent,
    GetPeopleComponent
  ]
})
export class PersonModule { }
