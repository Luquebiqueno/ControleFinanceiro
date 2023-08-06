import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
	const usuarioAutenticado = JSON.parse(localStorage.getItem('usuarioAutenticado'))
	const router = inject(Router);
	if (usuarioAutenticado && usuarioAutenticado.accessToken) {
		return true;
	} else {
		router.navigate(['autenticacao']);
		return false;
	}
};
