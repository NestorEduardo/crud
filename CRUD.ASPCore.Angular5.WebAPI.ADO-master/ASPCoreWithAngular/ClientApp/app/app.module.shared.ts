import { NgModule } from '@angular/core';
import { PeopleService } from './services/people.service';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { PeopleComponent } from './components/people/people.component';
import { CreatePersonComponent } from './components/createperson/createperson.component';

@NgModule({
    declarations: [
        AppComponent,
        PeopleComponent,
       CreatePersonComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'people', pathMatch: 'full' },
            { path: 'people', component: PeopleComponent },
            { path: 'people/create-person', component: CreatePersonComponent },
           { path:  'person/edit/:id', component: CreatePersonComponent },
            { path: '**', redirectTo: 'people' }
        ])
    ],
    providers: [PeopleService]
})
export class AppModuleShared {
}
