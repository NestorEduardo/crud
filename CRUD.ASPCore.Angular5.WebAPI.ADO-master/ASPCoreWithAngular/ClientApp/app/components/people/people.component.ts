import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { PeopleService } from '../../services/people.service'

@Component({
    selector: 'people',
    templateUrl: './people.component.html'
})

export class PeopleComponent {
    public people: IPeople[];

    constructor(public http: Http, private _router: Router, private _peopleService: PeopleService) {
        this.getPeople();
    }

    getPeople() {
        this._peopleService.getPeople().subscribe(
            data => this.people = data
        )
    }

    delete(personID) {
       var answer = confirm("¿Está seguro de eliminar la persona con el id : " + personID + "?");
       if (answer) {
          this._peopleService.deletePerson(personID).subscribe((data) => {
              this.getPeople();
           }, error => console.error(error)) 
      }
    }
}

interface IPeople {
    id: number;
    document: string;
    firstName: string;
    lastName: string;
    city: string;
    country: string;
}