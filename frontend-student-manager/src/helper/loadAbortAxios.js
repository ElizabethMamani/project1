const loadAbortAxios = () => {
  const controller = new AbortController();
  return controller;
};

export default loadAbortAxios;
