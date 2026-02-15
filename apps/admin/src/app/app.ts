import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
import { NxWelcome } from './nx-welcome';
import { AuthService } from './services/auth';

@Component({
  imports: [CommonModule, NxWelcome, RouterModule],
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App {
  private authService = inject(AuthService);
  private router = inject(Router);

  protected title = 'admin';
  public currentUser$ = this.authService.currentUser$;

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
