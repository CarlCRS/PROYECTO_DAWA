import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Header } from './components/header/header';
import { Footer } from './components/footer/footer';
import { CursosList } from './components/cursos-list/cursos-list';
import { CursosForm } from './components/cursos-form/cursos-form';


interface Curso {
  id: number;
  nombre: string;
  docente: string;
  activo: boolean;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [Header, Footer, CursosList, CursosForm, CommonModule],
  styleUrl: './app.css',
  templateUrl: './app.html',
})

export class App {
  mostrarMensaje: boolean = true;

  cursos: Curso[] = [
    { id: 1, 
      nombre: "CALIDAD DE SOFTWARE", 
      docente: "Tania Peralta - calidad/precio chayomi ", 
      activo: true 
    },
    { id: 2, 
      nombre: "INTELIGENCIA DE NEGOCIOS", 
      docente: " Silvia Tejada - La viejita de Inteligencia", 
      activo: true 
    },
    { id: 3, 
      nombre: "MARCO LEGAL DE LA PROFESIÓN", 
      docente: "Luis Merchan - El loco de Elibro", 
      activo: false 
    },
  ];

  agregarCurso(nuevoCurso: Curso) {
    this.cursos = [...this.cursos, nuevoCurso];
  }
  alternarMensaje() {
    this.mostrarMensaje = !this.mostrarMensaje;
  }
}
