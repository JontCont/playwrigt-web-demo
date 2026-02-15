import { Route } from '@angular/router';
import { NxWelcome } from './nx-welcome';
import { authGuard } from './auth/auth-guard';

export class AppRoutes {
    static readonly routes: Route[] = [
        {
            path: 'login',
            loadComponent: () => import('./auth/login/login').then(m => m.LoginComponent)
        },
        {
            path: '',
            component: NxWelcome,
            canActivate: [authGuard]
        }
    ];
}
