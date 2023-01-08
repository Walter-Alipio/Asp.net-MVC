class Carrinho {
	clickIncremento(btn) {
		let data = this.getData(btn);
		data.Quantidade++;
		this.postQuantidade(data);
	}

	clickDecremento(btn) {
		const data = this.getData(btn);
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
		const novaQtd = $(linhaDoItem).find('input').val(); //find acessa elementos abaixo na hierarquia do elemeto.

		return {
			Id: parseInt(itemId),
			Quantidade: novaQtd,
		};
	}

	postQuantidade(data) {
		console.log('entrei');
		console.log(JSON.stringify(data));
		$.ajax({
			url: '/pedido/updatequantidade',
			type: 'POST',
			contentType: 'application/json',
			dataType: 'json',
			data: JSON.stringify(data),
		});
	}
}

var carrinho = new Carrinho();
