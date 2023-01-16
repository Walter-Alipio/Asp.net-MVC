class Carrinho {
	clickIncremento(button) {
		let data = this.getData(button);
		data.Quantidade++;
		this.postQuantidade(data);
	}

	clickDecremento(button) {
		const data = this.getData(button);
		data.Quantidade--;
		this.postQuantidade(data);
	}

	updateQuantidade(input) {
		const data = this.getData(input);
		this.postQuantidade(data);
	}

	getData(elemento) {
		const linhaDoItem = $(elemento).parents('[item-id]'); //parents acessa elementos acima na hierarquia do elemento.
		const itemId = $(linhaDoItem).attr('item-id');
		const novaQuantidade = $(linhaDoItem).find('input').val(); //find acessa elementos abaixo na hierarquia do elemeto.

		return {
			Id: parseInt(itemId),
			Quantidade: novaQuantidade,
		};
	}

	postQuantidade(data) {
		const token = $('[name=__RequestVerificationToken]').val();
		const headers = {};
		headers['RequestVerificationToken'] = token;

		$.ajax({
			url: '/pedido/updatequantidade',
			type: 'POST',
			contentType: 'application/json',
			dataType: 'json',
			data: JSON.stringify(data),
			headers: headers,
		}).done(response => {
			let itemPedido = response.itemPedido;
			let linhaDoItem = $('[item-id=' + itemPedido.id + ']');
			linhaDoItem.find('input').val(itemPedido.quantidade);
			linhaDoItem.find('[subtotal]').html(itemPedido.subtotal.duasCasas());
			const carrinhoViewModel = response.carrinhoViewModel;
			$('[numero-itens]').html(
				`Total: ${carrinhoViewModel.itens.length} itens`
			);
			$('[total]').html(carrinhoViewModel.total.duasCasas());

			if (itemPedido.quantidade == 0) {
				linhaDoItem.remove();
			}
			// debugger;
		});
	}
}

var carrinho = new Carrinho();
Number.prototype.duasCasas = function () {
	return this.toFixed(2).replace('.', ',');
};
