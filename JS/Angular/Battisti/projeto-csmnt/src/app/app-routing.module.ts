import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { FistComponentComponent } from "./components/fist-component/fist-component.component";
import { ListRenderComponent } from "./components/list-render/list-render.component";
import { ItemDetailComponent } from "./components/item-detail/item-detail.component";

const routes: Routes = [
    {path:'', component: FistComponentComponent},
    {path:'list', component: ListRenderComponent},
    {path:'list/:id', component: ItemDetailComponent},
]

@NgModule({
    declarations: [],
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {}