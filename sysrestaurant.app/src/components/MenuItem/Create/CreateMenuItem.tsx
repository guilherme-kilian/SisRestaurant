import "./CreateMenuItem.css";

const CreateMenuItem : React.FC = () => {
    return <>
        <div className="container">
        <h2>Adicionar Itens ao Menu</h2>
        <form id="addItemForm">
            <div className="form-group">
                <label htmlFor="nomeItem">Nome do Item:</label>
                <input type="text" id="nomeItem" name="nomeItem" className="form-control" required />
            </div>
            <div className="form-group">
                <label htmlFor="descricaoItem">Descrição:</label>
                <textarea id="descricaoItem" name="descricaoItem" className="form-control" rows={3} required></textarea>
            </div>
            <div className="form-group">
                <label htmlFor="precoItem">Preço:</label>
                <input type="number" id="precoItem" name="precoItem" className="form-control" step="0.01" required />
            </div>
            <div className="form-group">
                <label htmlFor="imagemItem">Imagem do Item:</label>
                <input type="file" id="imagemItem" name="imagemItem" accept="image/*" className="form-control-file" required />
            </div>
            <button type="submit" className="btn btn-primary">Adicionar Item</button>
        </form>
    </div>
    </>
}

export default CreateMenuItem;