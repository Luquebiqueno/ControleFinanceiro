import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Gasto } from 'src/app/models/gasto';
import { GastoService } from 'src/app/services/gasto.service';
import { NotifierService } from 'src/app/services/notifier.service';

@Component({
    selector: 'app-gasto-edit',
    templateUrl: './gasto-edit.component.html',
    styleUrls: ['./gasto-edit.component.scss']
})
export class GastoEditComponent implements OnInit {

    gastoForm: FormGroup;
    gasto: Gasto;
    titulo = 'Cadastrar Gasto';
    id: string;

    constructor(private route: ActivatedRoute,
                private gastoService: GastoService,
                private fb: FormBuilder,
                private router: Router,
                private notifierService: NotifierService) { }

    ngOnInit(): void {
        this.getForm();
        this.id = this.route.snapshot.paramMap.get('id');
        if (this.id != null && this.id != undefined) {
            this.titulo = 'Editar Gasto';
            this.getGastoById(this.id);
        }
    }

    getForm(): void {
        this.gastoForm = this.fb.group({
            item: ['', [Validators.required]],
            valor: ['', [Validators.required]],
            dataCompra: ['', [Validators.required]],
            gastoTipoId: ['', [Validators.required]]
        });
    }

    getGastoById(id: string) {
        this.gastoService.getGastoById(id).subscribe((response: Gasto) => {
            if (response != null) {
                this.gastoForm = this.fb.group({
                    id: response.id,
                    item: response.item,
                    valor: response.valor,
                    dataCompra: response.dataCompra,
                    gastoTipoId: response.gastoTipoId
                });
            }
        });
    }

    salvar() {
        if (this.id != null && this.id != undefined) {
            this.updateGasto(this.id);
        } else {
            this.createGasto();
        }
    }

    createGasto(): void {
        if (this.gastoForm.invalid) {
            this.notifierService.showNotification('Dados inválidos', 'Erro', 'error');
            return;
        }

        this.gasto = this.gastoForm.value;
        this.gastoService.createGasto(this.gasto).subscribe((response: any) => {
            this.notifierService.showNotification('Gasto cadastrado com sucesso', 'Sucesso', 'success');
            this.voltar();
            
        },
        error => {
            this.notifierService.showNotification('Aconteceu um erro', 'Erro', 'error');
            return;
        });
    }

    updateGasto(id: string) {
        this.gasto = this.gastoForm.value;
        this.gastoService.updateGasto(id.toString(), this.gasto).subscribe((response: Gasto) => {
            this.notifierService.showNotification('Gasto Atualizado com sucesso', 'Sucesso', 'success');
            this.voltar();
        },
        error => {
            this.notifierService.showNotification('Aconteceu um erro', 'Erro', 'error');
        });
    }

    voltar(): void {
        this.router.navigate(['../../gasto']);
    }
}
