import { Component } from '@angular/core';
import { AuthService } from './core/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Dream AI Music Online shop';
  constructor(private authService: AuthService) {
    this.authService.initializeAuthenticationState();
  }
}
