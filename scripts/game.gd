extends CanvasLayer

func _ready() -> void:
	SignalBus.connect("show_city_hero_info", _on_show_city_hero_info)
	SignalBus.connect("hide_city_hero_info", _on_hide_city_hero_info)
	SignalBus.connect("hide_city_message", _on_hide_city_message)
	$Menu/UIAnimation.play('fade_in')

func _on_start_pressed() -> void:
	$Menu/UIAnimation.play('fade_out')
	$Menu.hide()
	$Map/CityContainer.show()
	$Map/SelectHero.show()

func _on_refuse_pressed() -> void:
	$Menu/UIAnimation.play('fade_in')
	$Menu.show()
	$Map/CityContainer.hide()
	$Map/SelectHero.hide()

func _on_decide_pressed() -> void:
	Global.is_press_select_button = true
	if(!Global.is_select_hero):
		var message1 = preload("res://scenes/game_state.tscn").instantiate()
		$".".add_child(message1)
		message1.show_message("[color=#ffde66][center]请在左边先选择一个君主角色", Vector2(10, 500), message1.Direction.Up, 1, 2)
		return
	$Map/SelectHero.hide()
	$GameUi.show()

func _on_button_pressed() -> void:
	$Map/CityMessage/HeroList/CharacterAttr.hide()

func _on_show_city_hero_info():
	$Map/CityMessage/HeroList/PopupPanel.popup()
	# $Map/CityMessage/HeroList/CharacterAttr.show()

func _on_hide_city_hero_info():
	$Map/CityMessage/HeroList/CharacterAttr.hide()

func _on_hide_city_message():
	$Map/CityMessage.hide()

func _on_texture_button_pressed() -> void:
	_on_refuse_pressed()
	$GameUi.hide()

func _on_button_deside_pressed() -> void:
	if(Global.polities_times <= 0):
		var message1 = preload("res://scenes/game_state.tscn").instantiate()
		$".".add_child(message1)
		message1.show_message("[color=#ffde66][center]没有政令了", Vector2(10, 500), message1.Direction.Up, 1, 2)
		return
	SignalBus.emit_signal("change_polities_times")
	# 关闭城市界面
	$popupTCQB/PopupPanel.hide()
	$Map/CityMessage.hide()
	# 允许查看城市界面
	Global.is_show_other_city_message = true

func _on_panel_wjyd_pressed() -> void:
	Global.save_move_jiang = []
	# 计算除了这个城市的所有其他武将列表
	var resultArray = []
	for city in Global.characters_select[Global.cur_character].citys:
		if(city != Global.cur_city):
			for jiang in Global.citys[city].curent_jiang:
				resultArray.append(jiang)
	if(!resultArray.size()):
		return
	SignalBus.emit_signal("change_wjyd_characters_ids", resultArray)
	$popupDJWJ/PopupPanel.popup()

func _on_wjyd_button_deside_pressed() -> void:
	if(Global.polities_times <= 0):
		var message1 = preload("res://scenes/game_state.tscn").instantiate()
		$".".add_child(message1)
		message1.show_message("[color=#ffde66][center]没有政令了", Vector2(10, 500), message1.Direction.Up, 1, 2)
		return
	# 找到这个编号在哪个城市，修改掉，然后塞进城市的列表中，通知城市界面更新
	for character_id in Global.save_move_jiang:
		# 从原来的城市中移除
		Global.citys[Global.characters[character_id].cityId].curent_jiang.erase(character_id)
		# 修改武将属于的城市
		Global.characters[character_id].cityId = Global.cur_city
		Global.citys[Global.cur_city].curent_jiang.append(character_id)
	SignalBus.emit_signal("change_polities_times")
	SignalBus.emit_signal("show_city_info", Global.citys[Global.cur_city].name, Global.cur_city)
	$popupDJWJ/PopupPanel.hide()

# 寻找人才
func _on_xzrc_panel_pressed() -> void:
	pass # Replace with function body.
