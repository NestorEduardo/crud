import { Component, OnInit, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { PeopleService } from '../../services/people.service';

@Component({
    selector: 'createperson',
    templateUrl: './createperson.component.html'
}) 

export class CreatePersonComponent implements OnInit {
    peopleForm: FormGroup;
    title: string = "Agregar";
    id: number;
    errorMessage: any;
    currentCityID: number
    public countries: ICountries[]
    public cities: ICities[]

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _peopleService: PeopleService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }

        this.peopleForm = this._fb.group({
            id: 0,
            document: ['', [Validators.required]],
            firstName: ['', [Validators.required]],
            lastName: ['', [Validators.required]],
            countryID: ['', [Validators.required]],
            c: ['', [Validators.required]]
        })
    }

    ngOnInit() {
          this.getCountries();

        if (this.id > 0) {
            this.title = "Editar";
            this._peopleService.getPersonById(this.id)
                .subscribe(resp => this.peopleForm.setValue(resp)
                , error => this.errorMessage = error);    
        }

    }

    save() {

        if (!this.peopleForm.valid) {
            return;
        }

        if (this.title == "Agregar") {
            this._peopleService.CreatePerson(this.peopleForm.value)
                .subscribe((data) => {
                    this._router.navigate(['person']);
                }, error => this.errorMessage = error)
        }

        else if (this.title == "Editar") {
            if(this._avRoute.snapshot.paramMap.get('id')) {
                let currentID = this._avRoute.snapshot.paramMap.get('id');
                let currentCityID = this._avRoute.snapshot.paramMap.get('cityID');
                this.id = currentID !== null ? parseInt(currentID): 0;
                this.currentCityID = currentCityID !== null ? parseInt(currentCityID): 0;
                this.peopleForm.controls['id'].setValue(this.id);
                 
debugger;

        }   

            this._peopleService.updatePerson(this.peopleForm.value)
                .subscribe((data) => {
                    this._router.navigate(['people']);
                }, error => this.errorMessage = error)
        }
    }

    cancel() {
        this._router.navigate(['/person']);
    }

    getCountries() {
        this._peopleService.getCountries().subscribe(
            data => this.countries = data
        )
    }

    getCities(countryID) {
        this._peopleService.getCities(countryID).subscribe(
            data => this.cities = data
        )
    }

    get document() { return this.peopleForm.get('document'); }
    get firstName() { return this.peopleForm.get('firstName'); }
    get lastName() { return this.peopleForm.get('lastName'); }
    get countryID() { return this.peopleForm.get('countryid'); }
    get cityID() { return this.peopleForm.get('cityid'); }
}

interface ICountries {
    id: number;
    description: string;
}

interface ICities {
    id: number;
    description: string;
}