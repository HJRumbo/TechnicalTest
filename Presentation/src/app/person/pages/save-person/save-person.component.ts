import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormValidationsService } from '../../../shared/services/form-validations.service';
import { Person } from '../../models/person';
import { PersonService } from '../../services/person.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-save-person',
  templateUrl: './save-person.component.html',
  styleUrls: ['./save-person.component.css']
})
export class SavePersonComponent implements OnInit {

  person?: Person;

  myForm: FormGroup = this.fb.group({
    names: ['', [Validators.required, Validators.maxLength(20)]],
    lastNames: ['', [Validators.required, Validators.maxLength(25)]],
    indentificationType: ['Seleccione', Validators.required],
    identificationNumber: ['', [Validators.required, Validators.maxLength(10), Validators.pattern('^[0-9]+$')]],
    email: ['', [Validators.required, Validators.maxLength(25), Validators.email]],
    userName: ['', [Validators.required, Validators.maxLength(10)]],
    password: ['', [Validators.required, Validators.maxLength(10)]],
    confirmPassword: ['', Validators.required],
  },
  {
    validators: [ this.fvService.matchPassword('password', 'confirmPassword') ]
  });

  constructor(private fb: FormBuilder, private fvService: FormValidationsService,
    private personService: PersonService) { }

  ngOnInit(): void {
  }

  register() {
    if(this.myForm.invalid){
      this.myForm.markAllAsTouched();

      console.log(this.myForm.controls);
      
      return;
    }

    console.log("entra");
    

    this.person = new Person();
    this.person = this.myForm.value;
    
    if(this.person)
      this.personService.post(this.person).subscribe(resp => {
        if (resp.isSuccess) {
          const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 2000,
            didOpen: (toast) => {
              toast.addEventListener('mouseenter', Swal.stopTimer)
              toast.addEventListener('mouseleave', Swal.resumeTimer)
            }
          })
          Toast.fire({
            icon: 'success',
            title: resp.message
          })

          this.myForm.reset();
        }
      });
    
  }
}
