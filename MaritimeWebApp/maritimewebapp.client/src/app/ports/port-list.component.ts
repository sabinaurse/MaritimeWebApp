import { Component, OnInit } from '@angular/core';
import { Port } from '../models/port.model';
import { PortService } from '../services/port.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-port-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './port-list.component.html'
})
export class PortListComponent implements OnInit {
  ports: Port[] = [];

  constructor(private portService: PortService) { }

  ngOnInit(): void {
    this.portService.getAll().subscribe(data => this.ports = data);
  }
}
