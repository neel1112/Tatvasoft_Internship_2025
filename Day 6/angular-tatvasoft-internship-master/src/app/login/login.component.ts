import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email = '';
  password = '';
  error = '';

  constructor(private auth: AuthService) {}

  onSubmit() {
    this.auth.login(this.email, this.password).subscribe({
      next: (res) => {
        // handle success (e.g., store token, redirect)
        alert('Login successful!');
      },
      error: (err) => {
        this.error = err.error?.message || 'Login failed';
      }
    });
  }
}
