import { Link, useParams } from "react-router-dom"
import PlusIcon from '/src/assets/plus-icon.png';
import { useEffect, useState } from "react";
import axios from "axios";


const PlacesPage = () => {
  const { action } = useParams();
  const [ufs, setUfs] = useState([]);

  useEffect(() => {
    axios
      .get("https://servicodados.ibge.gov.br/api/v1/localidades/estados/", { withCredentials: false })
      .then((response) => {
        setUfs(response.data);
      });
  }, []);


  return (
    <div>
      {action !== 'new' && (
        <div className="text-center">
          <Link className="inline-flex gap-2 bg-blue-900 text-white rounded-full py-2 px-4" to={'/account/places/new'}>
            Add new place
            <img src={PlusIcon} className="w-6" />
          </Link>
        </div>
      )}
      {action === 'new' && (
        <div className="flex justify-center">
          <form className="max-w-full">
            <h2 className="text-xl mt-4">Title</h2>
            <input type="text" placeholder="title" />
            <h2 className="text-xl mt-4">Street</h2>
            <input type="text" placeholder="street" />
            <h2 className="text-xl mt-4">City</h2>
            <input type="text" placeholder="City" />
            <h2 className="text-xl mt-4">Estado(UF)</h2>
            <select name="uf" id="uf" className="">
              <option value="0">Selecione uma Estado</option>
              {ufs.map((uf) => (
                <option key={uf.id} value={uf.sigla}>{uf.nome}</option>
              ))}
            </select>
            <h2 className="text-xl mt-4">CEP</h2>
            <input type="text" placeholder="CEP"/>
            <h2 className="text-xl mt-4">Photos</h2>
            <div className="mt-2 grid grid-cols-3 md:grid-cols-4 lg:grid-cols-6">
              <button className="border bg-trasnparent rounded-2xl p-8 text-2xl hover:bg-slate-200">+</button>
            </div>

          </form>
        </div>
      )}
    </div>
  )
}

export default PlacesPage