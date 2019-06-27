import { Component, OnInit, Input } from '@angular/core';
import { Entity } from 'src/app/models/Entity';
@Component({
  selector: 'app-entities-list',
  templateUrl: './entities-list.component.html',
  styleUrls: ['./entities-list.component.css']
})
export class EntitiesListComponent implements OnInit {
  @Input() entities: Entity[];

  constructor() {
  }

  ngOnInit() {
  }
}
