import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  name = '';
  email = '';
  number = '';
  address = '';

  // These hold the submitted data only
  submittedData = {
    name: '',
    email: '',
    number: '',
    address: ''
  };

  submitted = false;

  onSubmit() {
    this.submittedData = {
      name: this.name,
      email: this.email,
      number: this.number,
      address: this.address
    };
    this.submitted = true;
  }
}
