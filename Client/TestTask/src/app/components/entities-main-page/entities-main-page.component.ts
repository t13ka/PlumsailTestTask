import { FormGroup, FormBuilder } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EntitiesNewEntityComponent } from '../entities-new/entities-new-entity.component';
import { Entity } from 'src/app/models/Entity';
import { EntitiesService } from 'src/app/services/api/entities.service';

@Component({
  selector: 'app-entities-main-page',
  templateUrl: './entities-main-page.component.html',
  styleUrls: ['./entities-main-page.component.css']
})
export class EntitiesMainPageComponent implements OnInit {
  form: FormGroup;
  entities: Entity[];

  constructor(private modalService: NgbModal, private formBuilder: FormBuilder, private entitiesService: EntitiesService) { }

  ngOnInit() {
    this.form = this.formBuilder.group({
      Query: [''],
    });
    this.getEntities();
  }

  openNewEntityDialog() {
    const modalRef = this.modalService.open(EntitiesNewEntityComponent, { backdrop: false });
    modalRef.componentInstance.action.subscribe(() => {
      this.getEntities();
    });
  }

  submit() {
    const query = this.form.value.Query;
    this.entitiesService.find(query).subscribe(entities => {
      this.entities = entities;
    });
  }

  private getEntities() {
    this.entitiesService.get().subscribe(entities => {
      this.entities = entities;
    });
  }
}
