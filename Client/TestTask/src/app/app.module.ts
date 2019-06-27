import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UiSwitchModule } from 'ngx-toggle-switch';
import { HttpClientModule } from '@angular/common/http';

// * custom components
import { EntitiesMainPageComponent } from './components/entities-main-page/entities-main-page.component';
import { EntitiesListComponent } from './components/entities-list/entities-list.component';
import { EntitiesNewEntityComponent } from './components/entities-new/entities-new-entity.component';

@NgModule({
  declarations: [
    AppComponent,
    EntitiesMainPageComponent,
    EntitiesListComponent,
    EntitiesNewEntityComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    UiSwitchModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [
    EntitiesMainPageComponent,
    EntitiesNewEntityComponent
  ]
})
export class AppModule { }
