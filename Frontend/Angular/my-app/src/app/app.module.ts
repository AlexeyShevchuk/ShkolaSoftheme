import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { TestComponent } from './test/test.component';

@NgModule({
	declarations: [
		AppComponent,
		TestComponent
		],
	imports: [BrowserModule],
	bootstrap: [AppComponent]
})
export class AppModule { }