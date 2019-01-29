import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class PeopleService {
    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getPeople() {
        return this._http.get(this.myAppUrl + 'api/People/Index')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getPersonById(id: number) {
        return this._http.get(this.myAppUrl + "api/People/Details/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    CreatePerson(person) {
        return this._http.post(this.myAppUrl + 'api/People/Create', person)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updatePerson(person) {
        return this._http.put(this.myAppUrl + 'api/People/Edit', person)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deletePerson(id) {
        return this._http.delete(this.myAppUrl + "api/People/Delete/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getCountries() {
        return this._http.get(this.myAppUrl + 'api/People/GetCountries')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getCities(countryID) {
        return this._http.get(this.myAppUrl + 'api/People/GetCities' + countryID)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}