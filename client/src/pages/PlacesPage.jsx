import { Link, useParams } from "react-router-dom"
import PlusIcon from '/src/assets/plus-icon.png';
import { useEffect, useState } from "react";
import axios from "axios";
import UploadIcon from '/src/assets/upload-icon.png'
import InputMask from 'react-input-mask';


const PlacesPage = () => {
  const { action } = useParams();
  const [lstUfs, setLstUfs] = useState([]);
  const [perks, setPerks] = useState([]);
  const [checkedPerks, setCheckedPerks] = useState([]);
  const [title, setTitle] = useState('');
  const [street, setStreet] = useState('');
  const [city, setCity] = useState('');
  const [uf, setUf] = useState('');
  const [cep, setCep] = useState('');
  const [addedPhotos, setAddedPhotos] = useState();
  const [photoLink, setPhotoLink] =useState('');
  const [description, setDescription] = useState('');
  const [extrainfo, setExtraInfo] = useState('');
  const [checkIn, setCheckIn] = useState('')
  const [checkOut, setCheckOut] = useState('');
  const [maxGuests, setMaxGuests] = useState(1);

  const getStates = async () => {
    await axios
      .get("https://servicodados.ibge.gov.br/api/v1/localidades/estados/", { withCredentials: false })
      .then((response) => {
        setLstUfs(response.data);
      });
  }

  const getPerks = async () => {
    await axios.get("/Perk").then((response) => {
      setPerks(response.data)
    });
  }

  const handleCheckboxChange = (perkId) => {
    if (checkedPerks.includes(perkId)) {
      setCheckedPerks(checkedPerks.filter((id) => id !== perkId));
    } else {
      setCheckedPerks([...checkedPerks, perkId]);
    }
  };

  useEffect(() => {
    getStates();
    getPerks();
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
          <form className="max-w-2xl">
            <h2 className="text-xl mt-4">Title</h2>
            <input type="text" placeholder="title" value={title} onChange={(e) => setTitle(e.target.value)}/>
            <h2 className="text-xl mt-4">Street</h2>
            <input type="text" placeholder="street" value={street} onChange={(e) => setStreet(e.target.value)}/>
            <h2 className="text-xl mt-4">City</h2>
            <input type="text" placeholder="City" value={city} onChange={(e) => setCity(e.target.value)}/>
            <h2 className="text-xl mt-4">Estado(UF)</h2>
            <select name="uf" id="uf" className="" value={uf} onChange={(e) => setUf(e.target.value)}>
              <option value="0">Selecione uma Estado</option>
              {lstUfs.map((uf) => (
                <option key={uf.id} value={uf.sigla}>{uf.nome}</option>
              ))}
            </select>
            <h2 className="text-xl mt-4">CEP</h2>
            <input type="text" placeholder="CEP" value={cep} onChange={(e) => setCep(e.target.value)}/>
            <h2 className="text-xl mt-4">Photos</h2>
            <div className="flex gap-2">
              <input type="text" placeholder={"Add using a link ...jpg"} value={photoLink} onChange={(e) => setPhotoLink(e.target.value)}/>
              <button className="bg-gray-200 grow px-4 rounded-2xl"> Add&nbsp;Photo</button>
            </div>
            <div className="mt-2 grid grid-cols-3 md:grid-cols-4 lg:grid-cols-6">
              <button className="border bg-transparent rounded-2xl p-8 text-2 flex justify-center gap-2">
                <img src={UploadIcon} alt="" /> <span>Upload</span>
              </button>
            </div>
            <h2 className="text-xl mt-4">Description</h2>
            <textarea placeholder="Description of the place" value={description} onChange={(e) => setDescription(e.target.value)}/>
            <h2 className="text-xl mt-4">Perks</h2>
            <p className="text-gray-500 text-sm">select all the perks of your place</p>
            <div className="grid grid-cols-2 md:grid-cols-4 gap-2 mt-2">
              {perks && perks.map((perk) => (
                <label key={perk.id} className="border p-4 flex rounded-2xl gap-2 items-center cursor-pointer">
                  <input
                    type="checkbox"
                    onChange={() => handleCheckboxChange(perk.id)}
                    checked={checkedPerks.includes(perk.id)}
                  />
                  <span className="text-clip overflow-hidden">{perk.name}</span>
                </label>
              ))}
            </div>
            <h2 className="text-xl mt-4">Extra info</h2>
            <textarea placeholder="house rules, etc.." value={extrainfo} onChange={(e) => setExtraInfo(e.target.value)} />
            <h2 className="text-xl mt-4">Check in&out time, max guests</h2>
            <div className="grid gap-2 sm:grid-cols-3">
              <div>
                <h3 className="mt-2 -mb-1">Check in time</h3>
                {/* <input type="text" placeholder="14" value={checkIn} onChange={(e) => setCheckIn(e.target.value)}/> */}
                <InputMask
                className="input-mask"
                  mask={"99:99"}
                  value={checkIn}
                  onChange={(e) => setCheckIn(e.target.value)}
                  placeholder="HH:mm"
                />
              </div>
              <div>
                <h3 className="mt-2 -mb-1">Check out time</h3>
                <InputMask
                className="input-mask"
                  mask={"99:99"}
                  value={checkOut}
                  onChange={(e) => setCheckOut(e.target.value)}
                  placeholder="HH:mm"
                />
              </div>
              <div>
                <h3 className="mt-2 -mb-1">Max number of guests</h3>
                <input type="text" value={maxGuests} onChange={(e) => setMaxGuests(Number.parseInt(e.target.value))}/>
              </div>
            </div>
            <button className="primary my-4">Save</button>
          </form>
        </div>
      )}
    </div>
  )
}

export default PlacesPage