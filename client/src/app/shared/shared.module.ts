import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { ValidationMessagesComponent } from './validators/validation-messages.component';

@NgModule({
  declarations: [ValidationMessagesComponent],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    ToastrModule.forRoot({
      timeOut: 1000,
      preventDuplicates: true,
    }),
    HttpClientModule,
  ],
  exports: [ValidationMessagesComponent, FormsModule, ReactiveFormsModule],
})
export class SharedModule {}