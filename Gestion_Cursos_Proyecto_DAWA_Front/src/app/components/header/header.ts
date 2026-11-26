import { Component } from '@angular/core';

@Component({
  imports: [],
  selector: 'app-header',
  standalone: true,
  styleUrl: './header.css',
  templateUrl: './header.html',
})
export class Header {
  titulo='PROYECTO_DAWA';
  descripcion='Sistema web de gestión de cursos';
  curso='Desarrollo de aplicaciones web avanzado';
}
