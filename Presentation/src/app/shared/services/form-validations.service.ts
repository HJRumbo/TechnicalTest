import { Injectable } from '@angular/core';
import { AbstractControl, ValidationErrors } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class FormValidationsService {

  constructor() { }

  matchPassword( password: string, confirmPassword: string ) {
    return ( formGroup: AbstractControl ): ValidationErrors | null => {

      const pass = formGroup.get(password)?.value;
      const confirmPass = formGroup.get(confirmPassword)?.value;

      if ( pass !== confirmPass ) {
        formGroup.get(confirmPassword)?.setErrors({ noMatch: true })
        return { noMatch: true };
      }

      formGroup.get(confirmPassword)?.setErrors(null)
      
      return null;
    }
  } 
}
