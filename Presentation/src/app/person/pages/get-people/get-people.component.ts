import { Component, OnInit } from '@angular/core';
import { Person } from '../../models/person';
import { PersonService } from '../../services/person.service';

@Component({
  selector: 'app-get-people',
  templateUrl: './get-people.component.html',
  styleUrls: ['./get-people.component.css']
})
export class GetPeopleComponent implements OnInit {

  people?: Person[];

  constructor(private personService: PersonService) { }

  ngOnInit(): void {
    this.personService.getAllPeople().subscribe(p => this.people = p);
  }

}
