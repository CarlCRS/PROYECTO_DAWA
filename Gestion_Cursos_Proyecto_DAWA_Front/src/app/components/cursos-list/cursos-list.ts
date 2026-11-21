import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

interface Curso {
  id: number;
  nombre: string;
  docente: string;
  activo: boolean;
}

@Component({
  imports: [CommonModule],
  selector: 'app-cursos-list',
  standalone: true,
  styleUrl: './cursos-list.css',
  templateUrl: './cursos-list.html',
})

export class CursosList {
  @Input() cursos: Curso[] = [];

  // Eliminar si no se utiliza el cambiar estado del curso
  cambiarEstado(curso: Curso) {
    curso.activo = !curso.activo;
  }
}
