import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  email = '';
  password = '';
  error = '';

  constructor(private auth: AuthService) {}

  onSubmit() {
    this.auth.register(this.email, this.password).subscribe({
      next: (res) => {
        alert('Registration successful!');
      },
      error: (err) => {
        this.error = err.error?.message || 'Registration failed';
      }
    });
  }
}
