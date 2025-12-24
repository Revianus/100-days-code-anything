import pymem

pm = pymem.Pymem("PlantsVsZombiesRH.exe")  # ini nyambungin ke game nya

address = 0x12AD62A042C  # address tempat nyimpen uang

uang = pm.read_int(address)  # baca duit sekarang
print("Duit lu sekarang:", uang)

user_input = int(input("lu mau nambah berapa duit? "))

pm.write_int(address, user_input)  # nulis duit baru
print("duit lu sekarang jadi segini:", user_input)

pm.close_proccess()  # nutup koneksi ke game