import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { formatDate } from '@angular/common';
import { Subject } from 'rxjs';
import { Entity } from 'src/app/models/Entity';
import { EntitiesService } from 'src/app/services/api/entities.service';

@Component({
  selector: 'app-entities-new-entity',
  templateUrl: './entities-new-entity.component.html',
  styleUrls: ['./entities-new-entity.component.css']
})
export class EntitiesNewEntityComponent implements OnInit {
  action = new Subject<Entity>();
  form: FormGroup;

  private dateFormat = 'yyyy-MM-dd';
  private locale = 'en-US';

  constructor(private activeModal: NgbActiveModal, private formBuilder: FormBuilder, private entitiesService: EntitiesService) {
  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      Quantity: [1, [Validators.required, Validators.min(1)]],
      Email: ['', [Validators.required, Validators.email]],
      Color: ['', [Validators.required]],
      Notes: [''],
      // adding the custom validation for date ranges isn't according to this task, so it is skipped
      ShippingDate: [this.getTodayDate(), [Validators.required]],
      Shipping: [false],
    });
  }

  close() {
    this.activeModal.close();
  }

  submit() {
    this.entitiesService.add(this.form.value).subscribe(result => {
      this.action.next(Object.assign(new Entity(), result));
      this.activeModal.close();
    }, error => {
      // todo: show an error in UI
    });
  }

  getTodayDate(): string {
    return formatDate(new Date(), this.dateFormat, this.locale);
  }

  getMaxShippingDate(): string {
    const dt = new Date();
    dt.setDate(dt.getDate() + 14);
    return formatDate(dt, this.dateFormat, this.locale);
  }
}
