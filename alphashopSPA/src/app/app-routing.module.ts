import { RouteGuardService } from './services/routeGuard/route-guard.service';
import { LogoutComponent } from './logout/logout.component';
import { ArticoliComponent } from './articoli/articoli.component';
import { ErrorComponent } from './error/error.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'index', component: LoginComponent },
  { path: 'login', component: LoginComponent },
  { path: 'welcome/:userId', component: WelcomeComponent, canActivate: [RouteGuardService] },
  { path: 'articoli', component: ArticoliComponent, canActivate: [RouteGuardService]  },
  { path: 'logout', component: LogoutComponent },
  { path: '**', component: ErrorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
